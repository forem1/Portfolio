type
  matrix = array [1..100, 1..100] of integer;

var
  a: matrix;
  MinI, MinJ, M, N, i, j: Integer;

procedure DelMatrixString(var mat: matrix; X: Integer);
var
  i, j: integer;
begin
  M := M - 1;
  for i := X to M do
    for j := 1 to N do
      mat[i, j] := mat[i + 1, j];
end;

begin
  Write('N: ');
  Readln(N);
  Write('M: ');
  Readln(M);
  
  for i := 1 to M do
  begin
    writeln(i, ': ');
    for j := 1 to N do
    begin
      Write(j, ' : ');
      Read(a[i, j]);
    end;
  end;
  MinI := 1;
  MinJ := 1;
  for j := 1 to N do
    for i := 1 to M do
      if a[i, j] < a[MinI, MinJ] then
      begin
        MinI := i;
        MinJ := j;
      end;
  
  
  DelMatrixString(a, MinI);
  
  for i := 1 to M do
  begin
    for j := 1 to N do
    begin
      Write(' : ', a[i, j]);
    end;
    writeln(' : ');
  end;
end.