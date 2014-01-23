jQuery(document).ready(function () {
    jQuery('#imgPicture').Jcrop({
        onSelect: storeCoords
    });
});

function storeCoords(c) {
    jQuery('#X').val(c.x);
    jQuery('#Y').val(c.y);
    jQuery('#W').val(c.w);
    jQuery('#H').val(c.h);
    jQuery('#tX').val(c.x);
    jQuery('#tY').val(c.y);
    jQuery('#tW').val(c.w);
    jQuery('#tH').val(c.h);
};
 
  