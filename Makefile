RUN = mono
CS = csc
TARGET = tangotyo.cs
OBJ = tangotyo.exe
DLL_DIR = DLL
GUI_DLL = GUIConfig.dll
CTL_DLL = User.dll
GUI_SRC = GUIConfig.cs
CTL_SRC = User.cs
LIB_OPT = /t:Library
REPO = github/push

all:
	$(CS) /r:$(GUI_DLL) /r:$(CTL_DLL) $(TARGET)
	$(RUN) $(OBJ)

build:
	$(CS) /r:$(GUI_DLL) /r:$(CTL_DLL) $(TARGET)

run:
	$(RUN) $(OBJ)

gdll:
	$(CS) $(LIB_OPT) $(GUI_SRC)
	$(CS) $(LIB_OPT) $(CTL_SRC)
	mv *.dll ../

pushexe:
	cp $(OBJ) $(REPO)

pushsrc:
	cp $(TARGET) $(REPO)
	cp -r $(DLL_DIR) $(REPO)
