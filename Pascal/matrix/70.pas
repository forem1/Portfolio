type
  matrix = array [1..100, 1..100] of integer;

var
  a: matrix;
  MaxI, MaxJ, K, M, N, i, j: Integer;

procedure AddMatrixString(var mat: matrix; X: Integer);
var
  i, j: integer;
begin
  if x > 0 then
  begin
    M := M + 1;
    for i := M downto X + 1 do
      for j := 1 to N do
        a[i, j] := a[i - 1, j];
  end;
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
  
  MaxI := 1;
  MaxJ := 1;
  for i := 1 to M do
    for j := 1 to N do
      if a[i, j] > a[MaxI, MaxJ] then
      begin
        MaxI := i;
        MaxJ := j;
      end;
  
  AddMatrixString(a, MaxI);
  
  for i := 1 to M do
  begin
    for j := 1 to N do
    begin
      Write(' : ', a[i, j]);
    end;
    writeln(' : ');
  end;
end.