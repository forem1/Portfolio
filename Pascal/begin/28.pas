var
  A, k, m: real;

begin
  readln(A);
  writeln('Результат:');
  k := A * A;
  writeln(' ', A, ' во второй степени:     ', k);
  m := A * k;
  writeln(' ', A, ' в третьей степени:     ', m);
  m := k * m;
  writeln(' ', A, ' в пятой степени:       ', m);
  k := m * m;
  writeln(' ', A, ' в десятой степени:     ', k);
  k := k * m;
  writeln(' ', A, ' в пятнадцатой степени: ', k);
end.