
    function GetControlName(ControlClientName)
    {
        var DateArray=ControlClientName.split("_");
        if(DateArray.length>2)
            return DateArray[2].toUpperCase().substring(3);
        else
            return DateArray[0].toUpperCase().substring(3);
    }
    
    function validateDate()
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
            if(ControlCollection[i].id.toUpperCase().indexOf("_REDT")!=-1 || ControlCollection[i].id.toUpperCase().indexOf("_EDT")!=-1)
            {
                if(ValidateEnglishDate(ControlCollection[i])==false)
                    return false;
            }
            else if(ControlCollection[i].id.toUpperCase().indexOf("_RDT")!=-1 || ControlCollection[i].id.toUpperCase().indexOf("_DT")!=-1)
            {
                if(ControlCollection[i].id.toUpperCase().indexOf("_DT")!=-1 && ControlCollection[i].value.trim()=="")
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
    
    function validateDateByControl(cntl)
    {
        var ControlCollection=document.getElementById(cntl);
        var ErrorMsg="";
        var DateElement;
        var Year;
        var Month;
        var Day;
        var ErrorControl=new Array();
        
        //for(var i=0;i<ControlCollection.length;i++)
        //{
            if(ControlCollection.id.toUpperCase().indexOf("_RDT")!=-1 || ControlCollection.id.toUpperCase().indexOf("_DT")!=-1)
            {
                if(ControlCollection.id.toUpperCase().indexOf("_DT")!=-1 && ControlCollection.value.trim()=="")
                {
                    ErrorMsg=ErrorMsg+"";
                }    
                else
                {
                    DateElement=ControlCollection.value.split("/");
                    
                    if(DateElement.length==3)
                    {
                        Day=DateElement[2];
                        Month=DateElement[1];
                        Year=DateElement[0];
                        //alert(isNaN(Year));
                        if((Year.length!=4) || (Month.length!=2) || (Day.length!=2)  || (Month<1 || Month>12) || (Day<1 || Day>32) || (isNaN(Year)==true) || (isNaN(Month)==true) || (isNaN(Day)==true))
                        {
                            ErrorMsg=ErrorMsg+ControlCollection.title+":  -  गलत मिति. मितिको प्रकार YYYY/MM/DD मा राख्नुहोस।\n";
                            ErrorControl.push(ControlCollection);
                        }
                    }
                    else
                    {
                        ErrorMsg=ErrorMsg+ControlCollection.title+":  -  मितिको प्रकार YYYY/MM/DD मा राख्नुहोस।\n";
                        ErrorControl.push(ControlCollection);
                    }
                }
            }
        //}
        
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