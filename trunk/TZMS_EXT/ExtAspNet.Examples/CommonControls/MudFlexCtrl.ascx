<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MudFlexCtrl.ascx.cs" Inherits="TZMS.Web.CommonControls.MudFlexCtrl" %>
<script language="JavaScript" type="text/javascript">
<!--
 
    // Version check for the Flash Player that has the ability to start Player Product Install (6.0r65)
    var hasProductInstall = DetectFlashVer(6, 0, 65);
   
    // Version check based upon the values defined in globals
    var hasRequestedVersion = DetectFlashVer(requiredMajorVersion, requiredMinorVersion, requiredRevision);

    var url = "<%= Url.ToString() %>";
    var ShowAddBtn = "<%= ShowAddBtn.ToString() %>";
    var ShowDelBtn = "<%= ShowDelBtn.ToString() %>";
    var SystemName = "<%= SystemName.ToString() %>";
    var RecordID = "<%= RecordID.ToString() %>";
    var AttributeName = "<%= AttributeName.ToString() %>";
    var DownloadUrl = "<%= DownloadUrl.ToString() %>";
    var FileType = "<%= FileType.ToString() %>";
    var FileSize = "<%= FileSize.ToString() %>";




    // Check to see if a player with Flash Product Install is available and the version does not meet the requirements for playback
    if (hasProductInstall && !hasRequestedVersion) {
        // MMdoctitle is the stored document.title value used by the installation process to close the window that started the process
        // This is necessary in order to close browser windows that are still utilizing the older version of the player after installation has completed
        // DO NOT MODIFY THE FOLLOWING FOUR LINES
        // Location visited after installation is complete if installation is required
        var MMPlayerType = (isIE == true) ? "ActiveX" : "PlugIn";
        var MMredirectURL = window.location;
        document.title = document.title.slice(0, 47) + " - Flash Player Installation";
        var MMdoctitle = document.title;
       
        AC_FL_RunContent(
		"src", "playerProductInstall",
		"FlashVars", "MMredirectURL=" + MMredirectURL + '&MMplayerType=' + MMPlayerType + '&MMdoctitle=' + MMdoctitle + "",
		"width", "100%",
		"height", "100%",
		"align", "middle",
		"id", "UploadApp",
		"quality", "high",
		"wmode", "transparent",
		"bgcolor", "#ffffff",
		"name", "UploadApp",
		"allowScriptAccess", "sameDomain",
		"type", "application/x-shockwave-flash",
		"pluginspage", "http://www.adobe.com/go/getflashplayer"
	);
    } else if (hasRequestedVersion) {
        // if we've detected an acceptable version
        // embed the Flash Content SWF when all tests are passed
      
        AC_FL_RunContent(
			"src", "../../App_Flash/UploadApp",
			"width", "510px",
			"height", "185px",
			"align", "middle",
			"id", "UploadApp",
			"quality", "high",
			"wmode", "transparent",
			"flashvars", "url=" + url + "&ShowAddBtn=" + ShowAddBtn + "&ShowDelBtn=" + ShowDelBtn + "&SystemName=" + SystemName + "&RecordID=" + RecordID + "&AttributeName=" + AttributeName + "&DownloadUrl=" + DownloadUrl + "&Columns=Size,ShortDate" + "&FileType=" + FileType + "&FileSize=" + FileSize,
			"bgcolor", "#F4F7FC",
			"name", "UploadApp",
			"allowScriptAccess", "sameDomain",
			"type", "application/x-shockwave-flash",
			"pluginspage", "http://www.adobe.com/go/getflashplayer"
	);
    } else {  // flash is too old or we can't detect the plugin
        var alternateContent = 'Alternate HTML content should be placed here. '
  	+ 'This content requires the Adobe Flash Player. '
   	+ '<a href=http://www.adobe.com/go/getflash/>Get Flash</a>';
        document.write(alternateContent);  // insert non-flash content
    }
 
// -->
</script>