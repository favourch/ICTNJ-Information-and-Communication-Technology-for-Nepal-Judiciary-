
function ValidateEmail(EmailControl) 
{
    var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
    var address=document.getElementById(EmailControl).value;
    var ErrMsg="";
    if(address=="")
    {
        ErrMsg="कृपया ई-मेल ठेगाना राख्नुहोस."
        document.getElementById(EmailControl).focus();
        document.getElementById(EmailControl).select();
        return ErrMsg;
    }
    
    if(reg.test(address) == false) 
    {
      ErrMsg="कृपया सहि ई-मेल ठेगाना राख्नुहोस.";
      document.getElementById(EmailControl).focus();
      document.getElementById(EmailControl).select();
      return ErrMsg;
    }
    return false;
}