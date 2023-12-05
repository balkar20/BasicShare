set myword=%1 



set firstletter=%myword:~0,1%
echo %firstletter%
set capitalized = pwsh -Command '%firstletter%'.toUpper()
echo %%capitalized
set newstring=%capitalized%%myword:~1%
echo %newstring%
