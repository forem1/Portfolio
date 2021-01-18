var
  A, B, C, i: Integer;

begin
  Write('A: ');
  Readln(A);
  Write('B: ');
  Readln(B);
  if B < A then Write('error')
  else
  begin
    C := 0;
    for i := A to B do C := C + sqr(i);
    Writeln(C);
  end
end.