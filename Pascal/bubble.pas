unit bubble;

interface

var
  arr: array[1..1000] of integer;
  arr2: array[1..30, 1..30] of integer;
  i, j, k, u, a, y, b, g, p, r: integer;

procedure Input(var i, j, k, u, a, y, b, g, p, r: Integer);
procedure FirstOut(var i, j, k, u, a, y, b, g, p, r: Integer);
procedure SecondOut(var i, j, k, u, a, y, b, g, p, r: Integer);

implementation

procedure Input(var i, j, k, u, a, y, b, g, p, r: Integer);
begin
writeln('Количество строк  ');
  read(a);
  writeln('Количество столбцов  ');
  read(b);
  writeln('Интервал чисел');
  readln(u);
  read(y);
  g := a * b;
  randomize;
  
  for i := 1 to g do 
  begin
    arr[i] := random(y) + u;
  end;
  writeln;
end;

procedure FirstOut(var i, j, k, u, a, y, b, g, p, r: Integer);
begin
  
  writeln('Исходный массив');
  writeln;
  for i := 1 to a do
    for j := 1 to b do
    begin
      r := r + 1;
      arr2[i, j] := arr[r];
    end;
  
  for i := 1 to a do 
  begin
    for j := 1 to b do 
      write(arr2[ i, j], '  ');
    writeln
  end;
  
  writeln;
  writeln;
  
  
  for i := 1 to g - 1 do
    for j := 1 to g - i do
      if arr[j] > arr[j + 1] then begin
        k := arr[j];
        arr[j] := arr[j + 1];
        arr[j + 1] := k
      end;
end;

procedure SecondOut(var i, j, k, u, a, y, b, g, p, r: integer);
begin
  
  writeln('Сортированный массив');
  writeln;
  for i := 1 to a do
    for j := 1 to b do
    begin
      p := p + 1;
      arr2[i, j] := arr[p];
    end;
  
  for i := 1 to a do 
  begin
    for j := 1 to b do 
      write(arr2[ i, j], '  ');
    writeln
  end;
end;

begin
end. 