; -------------------------------
; Start

  !define MUI_FILE "PDFMetadataEditor"
  !define MUI_VERSION ""
  !define MUI_PRODUCT "Free PDF Metadata Editor"
  !define PRODUCT_SHORTCUT "Free PDF Metadata Editor"
  !define MUI_ICON "pdf_properties_changer.ico"
  !define PRODUCT_VERSION "3.8"
	
 ; !define LIBRARY_SHELL_EXTENSION

;  !define MUI_FINISHPAGE_SHOWREADME "$INSTDIR\readme.txt"

  Var RevenyouProduct
  !define MUI_CUSTOMFUNCTION_GUIINIT myGuiInit

  BrandingText "www.4dots-software.com"

  !include "MUI2.nsh"
  !include Library.nsh
  !include "x64.nsh"
  !include InstallOptions.nsh

  RequestExecutionLevel admin
  Name "Free PDF Metadata Editor"
  OutFile "FreePDFMetadataEditorSetup.exe"

  InstallDir "$PROGRAMFILES\4dots Software\${PRODUCT_SHORTCUT}"

  InstallDirRegKey HKLM "Software\4dots Software\Pdf Metadata Editor" ""

 !define DOT_MAJOR "2"
 !define DOT_MINOR "0"
 !define DOT_MINOR_MINOR "50727"

  var ALREADY_INSTALLED
 
;--------------------------------
;Interface Settings

  !define MUI_ABORTWARNING 
;--------------------------------
;General
 
  !insertmacro MUI_PAGE_WELCOME
;!!!  Page custom BundlePage
  !insertmacro MUI_PAGE_LICENSE "license_agreement.rtf" 
 ; !insertmacro MUI_PAGE_COMPONENTS
  !insertmacro MUI_PAGE_DIRECTORY 
  !insertmacro MUI_PAGE_INSTFILES
  
  Page custom OptionsPage
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES 

  ;!define MUI_FINISHPAGE_RUN 
  ;!define MUI_FINISHPAGE_RUN_FUNCTION "OpenWebpageFunction"
  ;!define MUI_FINISHPAGE_RUN_TEXT "Open Application Webpage for Information"
  
  Page custom DonatePage
  !insertmacro MUI_PAGE_FINISH
  
;--------------------------------
;Languages
 
  !insertmacro MUI_LANGUAGE "English" 

Function AddStartMenu
;create start-menu items
  CreateDirectory "$SMPROGRAMS\${PRODUCT_SHORTCUT}"
  CreateShortCut "$SMPROGRAMS\${PRODUCT_SHORTCUT}\${PRODUCT_SHORTCUT}.lnk" "$INSTDIR\${MUI_FILE}.exe" "" "$INSTDIR\${MUI_FILE}.exe" 0
  CreateShortCut "$SMPROGRAMS\${PRODUCT_SHORTCUT}\4dots Software PRODUCT CATALOG 2014.lnk" "$INSTDIR\4dots-Software-PRODUCT-CATALOG-2014.pdf" "" "$INSTDIR\4dots-Software-PRODUCT-CATALOG-2014.pdf" 0

  CreateShortCut "$SMPROGRAMS\${PRODUCT_SHORTCUT}\Free PDF Metadata Editor - User's Manual.url.lnk" "$INSTDIR\Free PDF Metadata Editor - User's Manual.url" "" "$INSTDIR\Free PDF Metadata Editor - User's Manual.url" 0
  CreateShortCut "$SMPROGRAMS\${PRODUCT_SHORTCUT}\Uninstall.lnk" "$INSTDIR\Uninstall.exe" "" "$INSTDIR\Uninstall.exe" 0

Functionend

Function AddDesktopShortcut
;create desktop shortcut
  CreateShortCut "$DESKTOP\${PRODUCT_SHORTCUT}.lnk" "$INSTDIR\${MUI_FILE}.exe" ""

FunctionEnd

Function IntegrateWindowsExplorer

 ${If} ${RunningX64}

!ifndef LIBRARY_X64
 !define LIBRARY_X64
!endif

   ExecWait '"$INSTDIR\vcredist_x64.exe" /q'

  !insertmacro InstallLib REGDLL $ALREADY_INSTALLED NOREBOOT_NOTPROTECTED .\FreePDFMetadataEditorShellExtx64.dll $SYSDIR\FreePDFMetadataEditorShellExt.dll $SYSDIR
  SetRegView 64
  SetShellVarContext all

${Else}

   ExecWait '"$INSTDIR\vcredist_x86.exe" /q'
  !insertmacro InstallLib REGDLL $ALREADY_INSTALLED NOREBOOT_NOTPROTECTED .\FreePDFMetadataEditorShellExt_vs2008_w7_x86.dll $SYSDIR\FreePDFMetadataEditorShellExt.dll $SYSDIR

${EndIf}  



FunctionEnd

Function AddQuickLaunch
  CreateShortCut "$QUICKLAUNCH\${PRODUCT_SHORTCUT}.lnk" "$INSTDIR\${MUI_FILE}.exe" ""
FunctionEnd
 
;-------------------------------- 
;Installer Sections     

Section "install" installinfo
  SetShellVarContext all

 ${If} ${RunningX64}
  SetRegView 64
; 64bit things here

${Else}

; 32bit things here

${EndIf}  



;Add files
  SetOutPath "$INSTDIR"
;  inetc::get /SILENT "http://www.4dots-software.com/installmonetizer/FreePDFMetadataEditor.php" "$PLUGINSDIR\Installmanager.exe" /end
  ;ExecWait "$PLUGINSDIR\Installmanager.exe 015" 

 Call IsDotNetInstalledAdv

  Delete $SYSDIR\PDFMetadataEditorShellExt.dll 
  Delete $SYSDIR\FreePDFMetadataEditorShellExt.dll 
  File "..\Debug\CryptoObfuscator_Output\${MUI_FILE}.exe"
  File "Free PDF Metadata Editor - User's Manual.url"
;  File "readme.txt"
  ;File "..\..\..\helpfile\Free PDF Metadata Editor - User's Manual.url";
  File "license_agreement.rtf"
  ;File "vcredist_x64.exe"
  ;File "vcredist_x86.exe"
  
  File "c:\code\misc\=redist\vcredist_x64.exe"
  File "c:\code\misc\=redist\vcredist_x86.exe"
  
  File "itextsharp.dll"
  File /oname=4dotsLanguageDownloader.exe "C:\code\Misc\4dotsLanguageDownloader\bin\Debug\4dotsLanguageDownloader.exe"
  
	File "Excel.dll"
	File "ICSharpCode.SharpZipLib.dll"
	File "LumenWorks.Framework.IO.dll"
  
  ;File "4dots-Software-PRODUCT-CATALOG-2014.pdf"
  ;File "Initial Files\drm.dat" 
  
  File "C:\code\Misc\=Redist\dotNetFx45_Full_setup.exe"    
  ;File "c:\code\misc\=redist\luminati\lum_sdk.dll"
  ;File "c:\code\misc\=redist\luminati\lum_sdk32.dll"
  ;File "c:\code\misc\=redist\luminati\net_updater32.exe"
  ;File /oname=LuminatiHelper.exe "c:\code\misc\=redist\luminati\LuminatiHelper-32.exe"
  ;File "..\debug\free-pdf-metadata-editor-150.png"
 
 Call CheckForDotVersion45Up
  Pop $0
  
  ${If} $0 == 0
  ;ExecWait '"$INSTDIR\dotNetFx45_Full_setup.exe"  /quiet /norestart'  
  ExecWait '"$INSTDIR\dotNetFx45_Full_setup.exe"'
  ;ExecWait '"$INSTDIR\NDP452-KB2901907-x86-x64-AllOS-ENU.exe"'
  ${EndIf}  
  
  ;nsExec::Exec "$INSTDIR\net_updater32.exe --install win_freepdfmetadataeditor.4dotssoftware.com"
  
;write uninstall information to the registry
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_SHORTCUT}" "DisplayName" "${PRODUCT_SHORTCUT} (remove only)"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_SHORTCUT}" "DisplayIcon" "$INSTDIR\${MUI_FILE}.exe"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_SHORTCUT}" "UninstallString" "$INSTDIR\Uninstall.exe"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_SHORTCUT}" "Publisher" "4dots Software"   

 ;Store installation folder
  WriteRegStr HKLM "Software\4dots Software\Pdf Metadata Editor" "" $INSTDIR
  WriteRegStr HKLM "Software\4dots Software\Pdf Metadata Editor" "InstallationDirectory" $INSTDIR
  WriteRegStr HKLM "Software\4dots Software\Pdf Metadata Editor" "Menu Item Caption" "Change PDF Properties"
 
  WriteUninstaller "$INSTDIR\Uninstall.exe"

  ;inetc::get /SILENT "http://www.4dots-software.com/dolog/dolog.php?request_file=${PRODUCT_SHORTCUT}&version=${PRODUCT_VERSION}" "$PLUGINSDIR\temptmp.txt"  /end
 
SectionEnd
 
 
;--------------------------------    
;Uninstaller Section  
Section "Uninstall"
   SetShellVarContext all

 ${If} ${RunningX64}

  SetRegView 64

!ifndef LIBRARY_X64
  !define LIBRARY_X64
!endif

  !insertmacro UnInstallLib REGDLL NOTSHARED NOREBOOT_NOTPROTECTED $SYSDIR\FreePDFMetadataEditorShellExt.dll
  SetRegView 64
   SetShellVarContext all
; 64bit things here

${Else}

; 32bit things here

  !insertmacro UnInstallLib REGDLL NOTSHARED NOREBOOT_NOTPROTECTED $SYSDIR\FreePDFMetadataEditorShellExt.dll


${EndIf}  

 ExecWait "$INSTDIR\${MUI_FILE}.exe /uninstall"  
 
 ;nsExec::Exec "$INSTDIR\net_updater32.exe --uninstall win_freepdfmetadataeditor.4dotssoftware.com" 

;Delete Files 
  RMDir /r "$INSTDIR\*.*"    

;Remove the installation directory
;  RMDir "$INSTDIR\de-DE"
  RMDir "$INSTDIR"

;Delete Start Menu Shortcuts
  Delete "$DESKTOP\${PRODUCT_SHORTCUT}.lnk"

  Delete "$SMPROGRAMS\${PRODUCT_SHORTCUT}\*.*"
  RmDir  "$SMPROGRAMS\${PRODUCT_SHORTCUT}"
 
;Delete Uninstaller And Unistall Registry Entries
  DeleteRegKey HKEY_LOCAL_MACHINE "SOFTWARE\${PRODUCT_SHORTCUT}"
  DeleteRegKey HKEY_LOCAL_MACHINE "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_SHORTCUT}"  
  DeleteRegKey HKLM "Software\4dots Software\Pdf Metadata Editor"
  DeleteRegKey HKCU "Software\4dots Software\Pdf Metadata Editor"

SetShellVarContext current
 RMDir /r "$PROGRAMFILES\4dots Software\${PRODUCT_SHORTCUT}\*.*"
 RMDir "$PROGRAMFILES\4dots Software\${PRODUCT_SHORTCUT}"

SectionEnd

;--------------------------------    
;MessageBox Section

 
;Function that calls a messagebox when installation finished correctly
Function .onInstSuccess
 ; MessageBox MB_OK "You have successfully installed ${MUI_PRODUCT}. Use the desktop icon to start the program."
 ExecShell "" "http://www.4dots-software.com/free-pdf-metadata-editor/how-to-use.php?afterinstall=true&version=${PRODUCT_VERSION}";
FunctionEnd
 
 
Function un.onUninstSuccess
  MessageBox MB_OK "You have successfully uninstalled ${MUI_PRODUCT}."
FunctionEnd
 
Function .onInit
  !insertmacro INSTALLOPTIONS_EXTRACT "NSISAdditionalActionsPage.ini"
FunctionEnd

Function myGUIInit
  SetShellVarContext all
 StrCpy $INSTDIR "$PROGRAMFILES\4dots Software\${PRODUCT_SHORTCUT}"
FunctionEnd

; Usage
; Define in your script two constants:
;   DOT_MAJOR "(Major framework version)"
;   DOT_MINOR "{Minor framework version)"
;   DOT_MINOR_MINOR "{Minor framework version - last number after the second dot)"
; 
; Call IsDotNetInstalledAdv
; This function will abort the installation if the required version 
; or higher version of the .NET Framework is not installed.  Place it in
; either your .onInit function or your first install section before 
; other code.
Function IsDotNetInstalledAdv
   Push $0
   Push $1
   Push $2
   Push $3
   Push $4
   Push $5
 
  StrCpy $0 "0"
  StrCpy $1 "SOFTWARE\Microsoft\.NETFramework" ;registry entry to look in.
  StrCpy $2 0
 
  StartEnum:
    ;Enumerate the versions installed.
    EnumRegKey $3 HKLM "$1\policy" $2
 
    ;If we don't find any versions installed, it's not here.
    StrCmp $3 "" noDotNet notEmpty
 
    ;We found something.
    notEmpty:
      ;Find out if the RegKey starts with 'v'.  
      ;If it doesn't, goto the next key.
      StrCpy $4 $3 1 0
      StrCmp $4 "v" +1 goNext
      StrCpy $4 $3 1 1
 
      ;It starts with 'v'.  Now check to see how the installed major version
      ;relates to our required major version.
      ;If it's equal check the minor version, if it's greater, 
      ;we found a good RegKey.
      IntCmp $4 ${DOT_MAJOR} +1 goNext yesDotNetReg
      ;Check the minor version.  If it's equal or greater to our requested 
      ;version then we're good.
      StrCpy $4 $3 1 3
      IntCmp $4 ${DOT_MINOR} +1 goNext yesDotNetReg
 
      ;detect sub-version - e.g. 2.0.50727
      ;takes a value of the registry subkey - it contains the small version number
      EnumRegValue $5 HKLM "$1\policy\$3" 0
 
      IntCmpU $5 ${DOT_MINOR_MINOR} yesDotNetReg goNext yesDotNetReg
 
    goNext:
      ;Go to the next RegKey.
      IntOp $2 $2 + 1
      goto StartEnum
 
  yesDotNetReg: 
    ;Now that we've found a good RegKey, let's make sure it's actually
    ;installed by getting the install path and checking to see if the 
    ;mscorlib.dll exists.
    EnumRegValue $2 HKLM "$1\policy\$3" 0
    ;$2 should equal whatever comes after the major and minor versions 
    ;(ie, v1.1.4322)
    StrCmp $2 "" noDotNet
    ReadRegStr $4 HKLM $1 "InstallRoot"
    ;Hopefully the install root isn't empty.
    StrCmp $4 "" noDotNet
    ;build the actuall directory path to mscorlib.dll.
    StrCpy $4 "$4$3.$2\mscorlib.dll"
    IfFileExists $4 yesDotNet noDotNet
 
  noDotNet:
    ;Nope, something went wrong along the way.  Looks like the 
    ;proper .NET Framework isn't installed.  
 
    ;Uncomment the following line to make this function throw a message box right away 
   MessageBox MB_OK "You must have v${DOT_MAJOR}.${DOT_MINOR}.${DOT_MINOR_MINOR} or greater of the .NET Framework installed.$\n$\nPlease download and install the .NET Redistributable from the Webpage that will open and run ${MUI_FILE}Setup.exe once again !"

  ${If} ${RunningX64}

	ExecShell "open" "http://www.microsoft.com/downloads/details.aspx?FamilyID=b44a0000-acf8-4fa1-affb-40e78d788b00"
  ${Else}

	ExecShell "open" "http://www.microsoft.com/downloads/details.aspx?FamilyID=0856eacb-4362-4b0d-8edd-aab15c5e04f5"
  ${EndIf}  




    Abort
     StrCpy $0 0
     Goto done
 
     yesDotNet:
    ;Everything checks out.  Go on with the rest of the installation.
    StrCpy $0 1
 
   done:
     Pop $4
     Pop $3
     Pop $2
     Pop $1
     Exch $0
 FunctionEnd

Function OptionsPage

  ; Prepare shortcut page with default values
  !insertmacro MUI_HEADER_TEXT "Additional Options" "Please select, whether shortcuts should be created."

  ; Display shortcut page
  !insertmacro INSTALLOPTIONS_DISPLAY_RETURN "NSISAdditionalActionsPage.ini"
  pop $R0 

  ${If} $R0 == "cancel"
    Abort
  ${EndIf} 

  ; Get the selected options

  ReadINIStr $R1 "$PLUGINSDIR\NSISAdditionalActionsPage.ini" "Field 2" "State"
  ReadINIStr $R2 "$PLUGINSDIR\NSISAdditionalActionsPage.ini" "Field 3" "State"
  ReadINIStr $R3 "$PLUGINSDIR\NSISAdditionalActionsPage.ini" "Field 4" "State"
  ReadINIStr $R4 "$PLUGINSDIR\NSISAdditionalActionsPage.ini" "Field 5" "State"

  ${If} $R1 == "1"  
    Call AddStartMenu
  ${EndIf}

  ${If} $R2 == "1"  
   Call AddDesktopShortcut
  ${EndIf}  

  ${If} $R3 == "1"  
   Call IntegrateWindowsExplorer
  ${EndIf}  

  ${If} $R4 == "1"  
   Call AddProductCatalogShortcut
  ${EndIf} 
  
FunctionEnd

Function .onGUIEnd
  Delete $INSTDIR\vcredist_x64.exe
  Delete $INSTDIR\vcredist_x86.exe

FunctionEnd

Function OpenWebpageFunction
  ExecShell "" "http://www.4dots-software.com/free-pdf-metadata-editor/how-to-use.php?afterinstall=true"
FunctionEnd

Function AddProductCatalogShortcut
  CreateShortCut "$DESKTOP\4dots Software PRODUCT CATALOG 2014.lnk" "$INSTDIR\4dots-Software-PRODUCT-CATALOG-2014.pdf" ""
FunctionEnd

Function DonatePage
   File /oname=$PLUGINSDIR\paypal-donate.bmp "C:\code\Misc\paypal-donate.bmp"
   
   Push $0
   Push $1

   !insertmacro MUI_HEADER_TEXT "Please Donate !" "Your donations are absolutely essential to us !"  
   nsDialogs::Create 1018
   Pop $0
   SetCtlColors $0 "" F0F0F0

   ${NSD_CreateBitmap} 150 50 73 44 ""
   Pop $0
   ${NSD_SetImage} $0 $PLUGINSDIR\\paypal-donate.bmp $1
   Push $1

   ; Register handler for click events
   ${NSD_OnClick} $0 DonateWebpage

   ${NSD_CreateLink} 50 120 100% 12 "Please Donate ! You donations are absolutely essential to us !"
   Pop $0
   ${NSD_OnClick} $0 DonateWebpage     
   
   nsDialogs::Show

   Pop $1
   ${NSD_FreeImage} $1

   Pop $1
   Pop $0 

FunctionEnd
 
Function DonateWebpage
	ExecShell "" "http://www.4dots-software.com/donate.php" 
FunctionEnd

; returns a numeric value on the stack, ranging from 0 to 450, 451, 452 or 460. 0 means nothing found, the other values mean at least that version
Function CheckForDotVersion45Up

  ReadRegDWORD $0 HKLM "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" Release

  IntCmp $0 393295 is46 isbelow46 is46

  isbelow46:
  IntCmp $0 379893 is452 isbelow452 is452

  isbelow452:
  IntCmp $0 378675 is451 isbelow451 is451

  isbelow451:
  IntCmp $0 378389 is45 isbelow45 is45

  isbelow45:
  Push 0
  Return

  is46:
  Push 460
  Return

  is452:
  Push 452
  Return

  is451:
  Push 451
  Return

  is45:
  Push 45
  Return

FunctionEnd
;eof
;eof