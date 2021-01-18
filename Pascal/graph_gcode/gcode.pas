uses GraphABC;

const
  N = 100;//100

var
  FileData: text;
  FileName: string;
  FileNum: integer;
  StringSum: integer = 0;
  XCoord: integer;
  YCoord: integer;
  b: integer;//отладочная

begin
  SetWindowTitle('gcode drawer'); //Заголовок окна
  SetPenWidth(3); //Толщина линии 3 пикселя
  SetPenColor(clRed); //Цвет линии красный
  
  read(FileNum);
  case FileNum of
    1: FileName := 'square';
    2: FileName := 'triangle';
    3: FileName := 'edge';
  end;
  
  assign(FileData, FileName + '.gcode');
  reset(FileData);
  
  var FileString: array [0..N] of string;
  
  while not eof(FileData) do 
  begin
    StringSum := StringSum + 1;
    readln(FileData, FileString[StringSum]);
    //Println(FileString[StringSum]); //выводим все значения из массива строк
  end;
  
  //Создаем массивы под координаты
  var XCoordArray: array [1..N] of string;
  var YCoordArray: array [1..N] of string;
  
  for var i := 1 to StringSum do 
  begin
    
    //Обрабатываем координату X
    foreach var X in FileString[i].Matches('[X]\d+') do 
    begin
      //Println(X.Value);
      XCoordArray[i] := X.Value.Where(c -> c <> 'X').JoinIntoString;
    end;
    
    //Обрабатываем координату Y
    foreach var Y in FileString[i].Matches('[Y]\d+') do 
    begin
      //Println(Y.Value);
      YCoordArray[i] := Y.Value.Where(c -> c <> 'Y').JoinIntoString;
    end;
    
    val(XCoordArray[i], XCoord, b);
    val(YCoordArray[i], YCoord, b);
    //print(XCoord);
    //println(YCoord);
    
    if i = 1 then
      MoveTo(XCoord, YCoord)
    else
      LineTo(XCoord, YCoord); //Рисуем линию
    
  end;
  
  //print(XCoord[1]);
  //print(YCoord[1]);
end.