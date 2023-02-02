cd %~dp0

if exist ..\.vs rmdir /q /s ..\.vs

if exist ..\csvnet\obj rmdir /q /s ..\csvnet\obj
if exist ..\csvnet.test\obj rmdir /q /s ..\csvnet.test\obj
if exist ..\csvnet.legacy\obj rmdir /q /s ..\csvnet.legacy\obj
if exist ..\csvnet.legacy.test\obj rmdir /q /s ..\csvnet.legacy.test\obj
