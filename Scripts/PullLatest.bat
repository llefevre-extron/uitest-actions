@ECHO off

:: Executable paths
SET curl="C:\Program Files\curl\bin\curl.exe"
SET zip="C:\Program Files\7-Zip\7z.exe"

:: Check that executables are installed; fail if not found.
IF NOT EXIST %curl% (
  ECHO Failed to find %curl%
  EXIT 2
)
IF NOT EXIST %zip% (
  ECHO Failed to find %zip%
  EXIT 2
)

:: Retrieve latest VCS versions metadata; fail if cannot connect to build repository.
ECHO Retrieving latest version of VCS build...
%curl% -sS -f -O http://uk-dfd-bldrepo1:8081/repository/StagingBuilds/VCSUISupport/WIP/maven-metadata.xml || (
  ECHO Failed to retrieve maven-metadata.xml from build repository.
  EXIT 1
)

:: Find latest VCS version tag and redirect to txt file
FINDSTR "latest" maven-metadata.xml > xmlTag.txt
FOR /f "tokens=3 delims=<;>;" %%a IN (xmlTag.txt) DO (
  SET version=%%a
)

:: Retrieve latest VCS installation zip file; fail if cannot connect to build repository.
ECHO Retrieving WIP-%version%-Nightly.zip from build repository...
%curl% -sS -O http://uk-dfd-bldrepo1:8081/repository/StagingBuilds/VCSUISupport/WIP/%version%/WIP-%version%-Nightly.zip || (
  ECHO Failed to retrieve WIP-%version%-Nightly.zip from build repository.
  EXIT 1
)

:: Extract zip file into VCS directory
ECHO Extracting WIP-%version%-Nightly.zip into VCS directory...
%zip% x WIP-%version%-Nightly.zip -o./VCS -y > NUL

:: Remove the leftover temporary files
IF EXIST "maven-metadata.xml" (
  DEL "maven-metadata.xml"
)
IF EXIST "xmlTag.txt" (
  DEL "xmlTag.txt"
)
IF EXIST "WIP-%version%-Nightly.zip" (
  DEL "WIP-%version%-Nightly.zip"
)
