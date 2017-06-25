    //-------------------------------------------------------------------------------------------------------
    // NB: Function for form validation
    //-------------------------------------------------------------------------------------------------------

    var mySplitResult;
    var myString;
    var myfocus ="";
    
       
    function callvalidate()
    {
        if(validate())
        {   callProgressbar();
            return true;
        }
    }
    
    function validate()
    {
       var doc = document.forms[0];
       var ErrMsg = "";  
       var objInputTxt = doc.getElementsByTagName("INPUT");
       //var objSelectTxt = doc.getElementsByTagName("SELECT");
         
       ErrMsg = validateTextBoxes(objInputTxt);
       //ErrMsg += validateDropDown(objSelectTxt);
       
       if (ErrMsg == "") 
            return true;
       else 
       {
            TotalErrMsg =  "सर्वप्रथम निम्न त्रुटिहरू सच्याउनुहोस।\n\n" + ErrMsg ;
            alert(TotalErrMsg);
           
            myfocus.focus();
            myfocus = "";
            return false;
       }
    }
   
    //-------------------------------------------------------------------------------------------------------
    // NB: Function to validate textboxes
    //-------------------------------------------------------------------------------------------------------
    
    function validateTextBoxes(objInputTxt)
    { 
        var txtErrrMsg = "";
        for (var j = 0; j < objInputTxt.length; j++)
	    {
    	    
	        if (objInputTxt[j].getAttribute("type") == "text")
		    {   
		        if (objInputTxt[j].getAttribute("id").search(/_rqd/i) != -1)
		        { 
		             if(objInputTxt[j].value == "")
		             {	
    		            
		                myString = (objInputTxt[j].id).toLowerCase();
		                mySplitResult = myString.split("txt");	   
		                txtErrrMsg += "- Please enter a "+ mySplitResult[1].split("_rqd")[0] +".\n";
                        
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
    // NB: Function to validate dropdowns
    //-------------------------------------------------------------------------------------------------------
    
    function validateDropDown(objSelectTxt)
    {
        var ddlErrMsg = "";
        
        for (var j = 0; j < objSelectTxt.length; j++)
	    {
	        if (objSelectTxt[j].getAttribute("id").search(/ddl/i) != -1)
		    {   
		         if(objSelectTxt[j].selectedIndex <= 0)
		         {	
		            myString = (objSelectTxt[j].id).toLowerCase();
    		      
		            mySplitResult = myString.split("ddl");
		            ddlErrMsg += "- Please enter a "+ mySplitResult[1].split("_rqd")[0] +".\n";
    		        
		            if(myfocus == "")
                    {
                        myfocus = objSelectTxt[j];
                    }
		         }
		    }
	    }
    	
	    return ddlErrMsg;
    }
    
    //-------------------------------------------------------------------------------------------------------
    // NB: Function to hide and show ProgressBar
    //-------------------------------------------------------------------------------------------------------
    function callProgressbar()
    {
       if (document.images["pleasewait"].style.visibility == "hidden")
            document.images["pleasewait"].style.visibility="";
       else
            document.images["pleasewait"].style.visibility ="hidden";
        
    }
 
    
    //-------------------------------------------------------------------------------------------------------
    // NB: Function to clear textboxes with button click
    //-------------------------------------------------------------------------------------------------------

    function clearForm()
    {      
           var doc = document.forms[0];
           var ErrMsg = "";  
           var objInputTxt = doc.getElementsByTagName("INPUT");
           
           for (var j = 0; j < objInputTxt.length; j++)
	       {
        	    
	            if (objInputTxt[j].getAttribute("type") == "text")
		        {   
    		           objInputTxt[j].value ="";
		               
		               if(myfocus == "")
                       {
                            myfocus = objInputTxt[j];
                       }
		        }
		    }
		   
		   /* 
		    
		   var objInputTxtArea = doc.getElementsByTagName("textarea");
           
           for (var i = 0; i < objInputTxtArea.length; i++)
	       {
        	    //alert( " value : " + objInputTxtArea[i].value);
	            if (objInputTxtArea[i].objInputTxtArea[i].value !== "")
		        {   
    		           objInputTxtArea[i].value ="";
		               
		               if(myfocus == "")
                       {
                            myfocus = objInputTxtArea[i];
                       }
		        }
		    }
		    
		    */
		    
		    if(myfocus != "")
		    { 
		        myfocus.focus();
                myfocus = "";
                return false;
		    }
		
    }
    
    //-------------------------------------------------------------------------------------------------------
    // NB: Function to clear checkboxes with button click
    //-------------------------------------------------------------------------------------------------------

    
    function clearCheckBox()
    {      
           var doc = document.forms[0];
           var objInputTxt = doc.getElementsByTagName("INPUT");
           
           for (var j = 0; j < objInputTxt.length; j++)
	       {
        	    if (objInputTxt[j].getAttribute("type") == "checkbox")
	            {
	                if(objInputTxt[j].checked)
	                    objInputTxt[j].checked = false;
		        }
		      
		    }
		    
     }
     
     
    //-------------------------------------------------------------------------------------------------------
    // NB: Function to clear DropDowns with button click
    //-------------------------------------------------------------------------------------------------------
     
    function clearDropDown()
    {      
           var doc = document.forms[0];
           var objInputTxt = doc.getElementsByTagName("Select");
           
           for (var j = 0; j < objInputTxt.length; j++)
	       {
        	  objInputTxt[j].value = 0;
		   }
		    
     }
    
    //-------------------------------------------------------------------------------------------------------
    // NB: Function to close form with button click
    //-------------------------------------------------------------------------------------------------------
    function FormClose()
    {
        //alert();
        //history.back(-1);
        window.close();
    }