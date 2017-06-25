// JScript File

function NumberOnly(evt,txt) 
{
    evt = (evt) ? evt : window.event
    var charCode = (evt.which) ? evt.which : evt.keyCode
	
	if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false
    }
    return true
}

function DecimalOnly(evt,txt) 
{
    evt = (evt) ? evt : window.event
    var charCode = (evt.which) ? evt.which : evt.keyCode
	
	if(charCode == 46 && txt.value.indexOf('.') < 0)
	{
		return true
	}
	
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false
    }
    return true
}

