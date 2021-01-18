program p;
var a,b:longint;
begin
     write('¬ведите число');
     readLn(a);
     b:=a*a;
     writeln('A^2 = ',b);
     a:=b*a;
     writeln('A^3 = ',a);
     a:=b*a;
     writeln('A^5 = ',a);
     b:=a*a;
     writeln('A^10 = ',b);
     a:=a*b;
     writeln('A^15 = ',a);
     readln;
end.