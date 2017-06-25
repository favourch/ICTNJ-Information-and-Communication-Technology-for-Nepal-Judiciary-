<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FancyBox.aspx.cs" Inherits="MODULES_OAS_Test_FancyBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>FancyBox 1.3.1 | Demonstration</title>

    <script src="../../COMMON/Fancy Box/jquery.fancybox-1.3.1/fancybox/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../../COMMON/Fancy Box/jquery.fancybox-1.3.1/fancybox/jquery.fancybox-1.3.1.js" type="text/javascript"></script>
    <link href="../../COMMON/Fancy Box/jquery.fancybox-1.3.1/fancybox/jquery.fancybox-1.3.1.css" media="screen" rel="stylesheet"
        type="text/css" />

    <script type="text/javascript">
		$(document).ready(function() {
			/*
			*   Examples - images
			*/

			$("a#example1").fancybox({
				'titleShow'		: false
			});

			$("a.example2").fancybox({
				'titleShow'		: false,
				'transitionIn'	: 'elastic',
				'transitionOut'	: 'elastic'
			});

			$("a#example3").fancybox({
				'titleShow'		: false,
				'transitionIn'	: 'none',
				'transitionOut'	: 'none'
			});

			$("a#example4").fancybox();

			$("a#example5").fancybox({
				'titlePosition'	: 'inside'
			});

			$("a#example6").fancybox({
				'titlePosition'	: 'over'
			});

			$("a[rel=example_group]").fancybox({
				'transitionIn'		: 'none',
				'transitionOut'		: 'none',
				'titlePosition' 	: 'over',
				'titleFormat'		: function(title, currentArray, currentIndex, currentOpts) {
					return '<span id="fancybox-title-over">Image ' + (currentIndex + 1) + ' / ' + currentArray.length + (title.length ? ' &nbsp; ' + title : '') + '</span>';
				}
			});

			/*
			*   Examples - various
			*/

			$("#various1").fancybox({
				'titlePosition'		: 'inside',
				'transitionIn'		: 'none',
				'transitionOut'		: 'none'
			});

			$("#various2").fancybox();

			$("#various3").fancybox({
				'width'				: '75%',
				'height'			: '75%',
				'autoScale'			: false,
				'transitionIn'		: 'none',
				'transitionOut'		: 'none',
				'type'				: 'iframe'
			});

			$("#various4").fancybox({
				'padding'			: 0,
				'autoScale'			: false,
				'transitionIn'		: 'none',
				'transitionOut'		: 'none'
			});
		});
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <a class="example2" href="../../COMMON/Fancy Box/jquery.fancybox-1.3.1/example/2_b.jpg">open image</a>&nbsp;<br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <a class="example2" href="#inline1">open div</a>&nbsp;<br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <a id="various3" href="http://www.google.com">open new page</a>
        <br />
        <br />
        <br />
        <div style="display: none;">
            <div id="inline1" style="overflow: auto; width: 406px; height: 152px">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam quis mi eu elit tempor facilisis id et neque. Nulla sit amet
                sem sapien. Vestibulum imperdiet porta ante ac ornare. Nulla et lorem eu nibh adipiscing ultricies nec at lacus. Cras laoreet
                ultricies sem, at blandit mi eleifend aliquam. Nunc enim ipsum, vehicula non pretium varius, cursus ac tortor. Vivamus fringilla
                congue laoreet. Quisque ultrices sodales orci, quis rhoncus justo auctor in. Phasellus dui eros, bibendum eu feugiat ornare,
                faucibus eu mi. Nunc aliquet tempus sem, id aliquam diam varius ac. Maecenas nisl nunc, molestie vitae eleifend vel, iaculis
                sed magna. Aenean tempus lacus vitae orci posuere porttitor eget non felis. Donec lectus elit, aliquam nec eleifend sit
                amet, vestibulum sed nunc.
            </div>
        </div>
    </div>
    </form>
</body>
</html>
