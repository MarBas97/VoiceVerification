function stat_and_disp(test_result,prog)
clc;
header=['    ','bartek ','seba ','aga ','test1 ','test2 '];
klasyfikacja=classyfication_test(test_result,prog);
disp(header);
disp(klasyfikacja);
false_positive=sum(sum((klasyfikacja)));
skutecznosc=((numel(klasyfikacja)-false_positive)/numel(klasyfikacja))*100;
disp(['skutecznoœæ wynosi: ', num2str(round(skutecznosc,2)),'%']);
disp(['próg wynosi: ', num2str(round(prog,2))]);





end

