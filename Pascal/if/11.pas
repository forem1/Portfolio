var
  A, B: Integer;

begin
  Write('Введите A: ');
  Readln(A);
  
  Write('Введите B: ');
  Readln(B);
  
  if A > B then
    B := A
  else if A < B then
    A := B
    else
  begin
    A := 0;
    B := 0;
  end;
  Writeln('A: ', A);
  Writeln('B: ', B);
end.