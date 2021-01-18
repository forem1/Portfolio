 type
  matrix = array [1..10, 1..10] of integer;

var
  a: matrix;
  M, i, j: Integer;

begin
  
  Write('M: ');
  Readln(M);
  writeln((M div 2) + (M mod 2) + 1);
  writeln(M mod 2);
  for  j := 1 to M do
  begin
    writeln(j, ': ');
    for i := 1 to M do
    begin
      Write(i, ' : ');
      Read(a[i, j]);
    end;
  end;
  
  for i := 1 to ((M div 2) + (M mod 2)) do
    for j := i to M - i + 1 do
      a[i, j] := 0;
  
  for  j := 1 to M do
  begin
    for i := 1 to M do
    begin
      Write(' : ', a[i, j]);
    end;
    Writeln(' : ');
  end;
end.