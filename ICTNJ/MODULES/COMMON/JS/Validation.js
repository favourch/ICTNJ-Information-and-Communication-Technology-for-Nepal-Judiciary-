  //-------------------------------------------------------------------------------------------------------
    // NB: Function for form validation
    //-------------------------------------------------------------------------------------------------------

    var mySplitResult;
    var myString;
    var myfocus ="";
    
      
    function validate(callDateValidator)
    {
        try
        {
           var doc = document.forms[0];
           var ErrMsg = "";  
           var objInputTxt = doc.getElementsByTagName("INPUT");
           var objSelectTxt = doc.getElementsByTagName("SELECT");
           var objTextAreaTxt=doc.getElementsByTagName("TEXTAREA");
           ErrMsg = validateTextBoxes(objInputTxt);
           ErrMsg += validateDropDown(objSelectTxt);
           ErrMsg+=validateTextAreas(objTextAreaTxt);
           
           if (ErrMsg == "")
           {
                if(callDateValidator==1)
                    return validateDate();
                else
                    return true;
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
    function validateTextBoxes(objInputTxt)
    {
   
        var txtErrrMsg = "";
        
        for (var j = 0; j < objInputTxt.length; j++)
	    {
    	    
	        if (objInputTxt[j].getAttribute("type") == "text" || objInputTxt[j].getAttribute("type") == "password")
		    {   
		        if (objInputTxt[j].getAttribute("id").search(/_rqd/i) != -1)
		        { 
		             if(objInputTxt[j].value == "")
		             {	
    		            
		                myString = (objInputTxt[j].id).toLowerCase();
		                mySplitResult = myString.split("txt");	   
		                //txtErrrMsg += "- Please enter a "+ mySplitResult[1].split("_rqd")[0] +".\n";
		                txtErrrMsg += "- कृपया "+  objInputTxt[j].title + " राख्नुहोस।\n";
                       
                        if(myfocus == "")
                        {
                            myfocus = objInputTxt[j];
                        }
		             }
	            }
	             
    		    
		    }
		    //alert(objInputTxt.length);
	    }
	    return txtErrrMsg;
    }

    //-------------------------------------------------------------------------------------------------------
    // NB: Function to validate TextArea
    //-------------------------------------------------------------------------------------------------------
    function validateTextAreas(objTextAreaTxt)
    {
   
        var txtErrrMsg = "";
        for (var j = 0; j < objTextAreaTxt.length; j++)
	    {
    	    
	        if (objTextAreaTxt[j].getAttribute("id").search(/_rqd/i) != -1)
		        { 
		             if(objTextAreaTxt[j].value == "")
		             {	
    		            
		                myString = (objTextAreaTxt[j].id).toLowerCase();
		                mySplitResult = myString.split("txt");	   
		                //txtErrrMsg += "- Please enter a "+ mySplitResult[1].split("_rqd")[0] +".\n";
		                txtErrrMsg += "- कृपया "+  objTextAreaTxt[j].title + " राख्नुहोस।\n";
                       
                        if(myfocus == "")
                        {
                            myfocus = objTextAreaTxt[j];
                        }
		             }
   
		    }
		    //alert(objInputTxt.length);
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
	        if (objSelectTxt[j].getAttribute("id").search(/rqd/i) != -1)
		    {   
		         if(objSelectTxt[j].selectedIndex <= 0)
		         {	
		            myString = (objSelectTxt[j].id).toLowerCase();
    		      
		            mySplitResult = myString.split("ddl");
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


     function clearForm()
    {      
        //alert();
            clearTextBox();
            clearTextArea();	
            clearCheckBox();
            clearDropDown();
            	    
		    
		    if(myfocus != "")
		    { 
		        //myfocus.focus();
                myfocus = "";
                return false;
		    }
		
    }
    
     //-------------------------------------------------------------------------------------------------------
    // NB: Function to clear textboxes 
    //-------------------------------------------------------------------------------------------------------
    function clearTextBox()
    {      
           var doc = document.forms[0];
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
		   
	}    
    
      //-------------------------------------------------------------------------------------------------------
    // NB: Function to clear TextAreas 
    //-------------------------------------------------------------------------------------------------------
    function clearTextArea()
    {      
           var doc = document.forms[0]; 
           var objInputTxtArea = doc.getElementsByTagName("textarea");
           
           for (var i = 0; i < objInputTxtArea.length; i++)
	       {
        	    if (objInputTxtArea[i].value != "")
		        {   
		               objInputTxtArea[i].value ="";
		               
		               if(myfocus == "")
                       {
                            myfocus = objInputTxtArea[i];
                       }
		        }
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
