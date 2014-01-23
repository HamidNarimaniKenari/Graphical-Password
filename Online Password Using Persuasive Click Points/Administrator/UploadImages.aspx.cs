using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using SD = System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;



public partial class Administrator_UploadImages : System.Web.UI.Page
{
    DBFunctions DB = new DBFunctions();
    MastersList ML = new MastersList();

    Byte[] Photo;
    #region This code is from persuasive cued click point

    String path = HttpContext.Current.Request.PhysicalApplicationPath + "Images\\";

    static byte[] Crop(string Img, int Width, int Height, int X, int Y)
    {
        try
        {
            using (SD.Image OriginalImage = SD.Image.FromFile(Img))
            {
                using (SD.Bitmap bmp = new SD.Bitmap(Width, Height))
                {
                    bmp.SetResolution(OriginalImage.HorizontalResolution, OriginalImage.VerticalResolution);
                    using (SD.Graphics Graphic = SD.Graphics.FromImage(bmp))
                    {
                        Graphic.SmoothingMode = SmoothingMode.AntiAlias;
                        Graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        Graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        Graphic.DrawImage(OriginalImage, new SD.Rectangle(0, 0, Width, Height), X, Y, Width, Height, SD.GraphicsUnit.Pixel);
                        MemoryStream ms = new MemoryStream();
                        bmp.Save(ms, OriginalImage.RawFormat);
                        return ms.GetBuffer();
                    }
                }
            }
        }
        catch (Exception Ex)
        {
            throw (Ex);
        }
    }

    void SaveImagePart(int intImageID,Byte[] CropImage)
    {
        //PersuasiveImgID, ImageID, ImagePart, , , , , ,
        string InsQry = "insert into PersuasiveImages(ImageID, ImagePart)" +
                                            " values(@ImageID, @ImagePart)";

        SqlCommand InsCmd = new SqlCommand(InsQry, DB.Connection);

        InsCmd.Parameters.Add(new SqlParameter("@ImageID", SqlDbType.SmallInt)).Value = intImageID;
        InsCmd.Parameters.Add(new SqlParameter("@ImagePart", SqlDbType.Image, CropImage.Length)).Value = CropImage;

        DB.Connection.Open();
        InsCmd.ExecuteNonQuery();
        DB.Connection.Close();
    }


    void SavePersuasiveImage()
    {
        int intImageID;
        //ImageID, PasswordModeID, ImageName, ImageFile, , , , , , 
        string InsQry = "insert into ImageUploads(PasswordModeID, ImageName, Image)" +
                                            " values(@PasswordModeID, @ImageName, @Image) set @ImageID = SCOPE_IDENTITY()";

        SqlCommand InsCmd = new SqlCommand(InsQry, DB.Connection);

        InsCmd.Parameters.Add(new SqlParameter("@PasswordModeID", SqlDbType.Int)).Value = int.Parse(ddlPasswordMode.SelectedValue);
        InsCmd.Parameters.Add(new SqlParameter("@ImageName", SqlDbType.VarChar, 50)).Value = txtImageTitle.Text;


        if (fileImages.PostedFile != null && fileImages.PostedFile.FileName != "")
        {
            using (BinaryReader reader = new BinaryReader(fileImages.PostedFile.InputStream))
            {
                Session["WorkingImage"] = fileImages.FileName;
                fileImages.PostedFile.SaveAs(path + Session["WorkingImage"]);
                Photo = reader.ReadBytes(fileImages.PostedFile.ContentLength);
            }
        }

        InsCmd.Parameters.Add(new SqlParameter("@Image", SqlDbType.Image, Photo.Length)).Value = Photo;

        SqlParameter prmImageID = new SqlParameter("@ImageID", SqlDbType.Int);
        prmImageID.Direction = ParameterDirection.Output;
        InsCmd.Parameters.Add(prmImageID);

        DB.Connection.Open();
        InsCmd.ExecuteNonQuery();
        DB.Connection.Close();

        intImageID = int.Parse(prmImageID.Value.ToString());


        string ImageName = path + Session["WorkingImage"].ToString();
        int w = 80;
        int h = 80;
        int x = 0;
        int y = 0;

        for (int i = 1; i <= 5; i++)
        {
            y = 0;
            for (int j = 1; j <= 5; j++)
            {
                byte[] img = Crop(ImageName, w, h, x, y);
                SaveImagePart(intImageID, img);
                y += 80;
            }
            x += 80;
        }
    }
    #endregion    
    
    void SaveImages()
    {
        //ImageID, PasswordModeID, ImageName, ImageFile, , , , , , 
        string InsQry = "insert into ImageUploads(PasswordModeID, ImageName, Image)" +
                                            " values(@PasswordModeID, @ImageName, @Image)";

        SqlCommand InsCmd = new SqlCommand(InsQry, DB.Connection);

        InsCmd.Parameters.Add(new SqlParameter("@PasswordModeID", SqlDbType.Int)).Value = int.Parse(ddlPasswordMode.SelectedValue);
        InsCmd.Parameters.Add(new SqlParameter("@ImageName", SqlDbType.VarChar, 50)).Value = txtImageTitle.Text;


        if (fileImages.PostedFile != null && fileImages.PostedFile.FileName != "")
        {
            using (BinaryReader reader = new BinaryReader(fileImages.PostedFile.InputStream))
            {
                Photo = reader.ReadBytes(fileImages.PostedFile.ContentLength);
            }
        }

        InsCmd.Parameters.Add(new SqlParameter("@Image", SqlDbType.Image, Photo.Length)).Value = Photo;

        DB.Connection.Open();
        InsCmd.ExecuteNonQuery();
        DB.Connection.Close();
    }
    void GetImages()
    {
        string QryStr = "select * from ImageUploads as i, PasswordMode as pm where i.PasswordModeID=pm.PasswordModeID order by i.PasswordModeID, ImageName";
        DataSet DSet = new DataSet();
        DB.GetData(QryStr, "ImageUploads", DSet);
        DataList1.DataSource = DSet;
        DataList1.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            ML.PasswordMode(ddlPasswordMode);
            GetImages();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (btnSubmit.Text == "Submit")
        {
            if (ddlPasswordMode.SelectedValue == "1" || ddlPasswordMode.SelectedValue == "2")
            {
                SaveImages();
            }
            else if (ddlPasswordMode.SelectedValue == "3")
            {
                SavePersuasiveImage();
            }
            lblMessage.Text = "Image saved successfully";
            btnSubmit.CausesValidation = false;
            btnSubmit.Text = "Ok";
            GetImages();
        }
        else
        {
            btnSubmit.CausesValidation = true;
            lblMessage.Text = "";
            txtImageTitle.Text = "";
            ddlPasswordMode.SelectedIndex = 0;
            btnSubmit.Text = "Submit";
        }
    }
}
