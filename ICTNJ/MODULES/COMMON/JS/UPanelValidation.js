  //-------------------------------------------------------------------------------------------------------
    // NB: Function for form validation
    //-------------------------------------------------------------------------------------------------------

    var mySplitResult;
    var myString;
    var myfocus ="";
    
      
    function validateUpanelFields(validationfields,callDateValidator)
    {
        try
        {
        
           var doc = document.forms[0];
           var ErrMsg = "";  
           var objInputTxt = doc.getElementsByTagName("INPUT");
           var objSelectTxt = doc.getElementsByTagName("SELECT");
           var objTextAreaTxt=doc.getElementsByTagName("TEXTAREA");
           ErrMsg = validateTextBoxesUpanelFields(validationfields,objInputTxt);
           ErrMsg += validateDropDownUpanelFields(validationfields,objSelectTxt);
           ErrMsg+=validateTextAreasUpanelFields(validationfields,objTextAreaTxt);
           if (ErrMsg == "")
           {
                if(callDateValidator=="")
                    return true
                else
                     return validateDateUpanelFields(callDateValidator);
           }
           else 
           {
                alert("सर्वप्रथम निम्न त्रुटिहरू सच्याउनुहोस।\n\n" + ErrMsg);               
                myfocus.focus();
                myfocus = "";
                return false;
           }
       }
       catch(err)
       {
            alert(err);
       }
    }


    //-------------------------------------------------------------------------------------------------------
    // NB: Function to validate textboxes
    //-------------------------------------------------------------------------------------------------------
    function validateTextBoxesUpanelFields(validationfields,objInputTxt)
    {
   
        var txtErrrMsg = "";
        for (var j = 0; j < objInputTxt.length; j++)
	    {
    	    
	        if (objInputTxt[j].getAttribute("type") == "text" || objInputTxt[j].getAttribute("type") == "password")
		    {   
		        if (objInputTxt[j].getAttribute("id").indexOf(validationfields) != -1)
		        { 
		             if(objInputTxt[j].value == "")
		             {	
		                txtErrrMsg += "- कृपया "+  objInputTxt[j].title + " राख्नुहोस।\n";
                       
                        if(myfocus == "")
                        {
                            myfocus = objInputTxt[j];
                        }
		             }
	            }
	             	    
		    }
	    }
	    return txtErrrMsg;
    }

    //-------------------------------------------------------------------------------------------------------
    // NB: Function to validate TextArea
    //-------------------------------------------------------------------------------------------------------
    function validateTextAreasUpanelFields(validationfields,objTextAreaTxt)
    {
   
        var txtErrrMsg = "";
        for (var j = 0; j < objTextAreaTxt.length; j++)
	    {
    	    
	        if (objTextAreaTxt[j].getAttribute("id").indexOf(validationfields) != -1)
		        { 
		             if(objTextAreaTxt[j].value == "")
		             {	
		                txtErrrMsg += "- कृपया "+  objTextAreaTxt[j].title + " राख्नुहोस।\n";
                       
                        if(myfocus == "")
                        {
                            myfocus = objTextAreaTxt[j];
                        }
		             }
   
		    }
	    }
	    return txtErrrMsg;
    }

    //-------------------------------------------------------------------------------------------------------
    // NB: Function to validate dropdowns
    //-------------------------------------------------------------------------------------------------------
    function validateDropDownUpanelFields(validationfields,objSelectTxt)
    {
        var ddlErrMsg = "";
        for (var j = 0; j < objSelectTxt.length; j++)
	    {
	        if (objSelectTxt[j].getAttribute("id").indexOf(validationfields) != -1)
		    {   
		         if(objSelectTxt[j].selectedIndex <= 0)
		         {	
		            ddlErrMsg += "- कृपया "+ objSelectTxt[j].title +" छान्नुहोस।\n";
    		        
		            if(myfocus == "")
                    {
                        myfocus = objSelectTxt[j];
                    }
		         }
		    }
	    }
    	
	    return ddlErrMsg;
    }


    function validateDateUpanelFields(callDateValidator)
    {
        var ControlCollection=document.getElementsByTagName("INPUT");
        var ErrorMsg="";
        var DateElement;
        var Year;
        var Month;
        var Day;
        var ErrorControl=new Array();
        for(var i=0;i<ControlCollection.length;i++)
        {
            if(ControlCollection[i].id.indexOf("_UREDT" + callDateValidator)!=-1 || ControlCollection[i].id.indexOf("_UEDT" + callDateValidator)!=-1)
            {
                if(ValidateEnglishDate(ControlCollection[i])==false)
                    return false;
            }
            else if(ControlCollection[i].id.indexOf("_URDT" + callDateValidator)!=-1 || ControlCollection[i].id.indexOf("_UDT" + callDateValidator)!=-1)
            {
                if(ControlCollection[i].id.indexOf("_UDT" + callDateValidator)!=-1 && ControlCollection[i].value.trim()=="")
                {
                    ErrorMsg=ErrorMsg+"";
                }    
                else
                {
                   // DateElement=ControlCollection[i].value.split(".");
                   DateElement=ControlCollection[i].value.split("/");
                    
                    if(DateElement.length==3)
                    {
                        Day=DateElement[2];
                        Month=DateElement[1];
                        Year=DateElement[0];
                        //alert(isNaN(Year));
                        if((Year.length!=4) || (Month.length!=2) || (Day.length!=2)  || (Month<1 || Month>12) || (Day<1 || Day>32) || (isNaN(Year)==true) || (isNaN(Month)==true) || (isNaN(Day)==true))
                        {
                            ErrorMsg=ErrorMsg+ControlCollection[i].title+":  -  गलत मिति. मितिको प्रकार YYYY/MM/DD मा राख्नुहोस।\n";
                            ErrorControl.push(ControlCollection[i]);
                        }
                    }
                    else
                    {
                        ErrorMsg=ErrorMsg+ControlCollection[i].title+":  -  मितिको प्रकार YYYY/MM/DD मा राख्नुहोस।\n";
                        ErrorControl.push(ControlCollection[i]);
                    }
                }
            }
        }
        
        if(ErrorMsg!="")
        {
            alert("निम्न मितिको त्रुटिहरू सच्याउनुहोस::\n\n"+ErrorMsg);
            ErrorControl[0].focus();
            ErrorControl[0].select();
            return false;
        }
        else
        {
            return true;
        }
}