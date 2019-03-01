function result = classyfication_test(tab,prog)
[w,k]=size(tab);
for i=1:w
   for j=1:k
      if(tab(i,j)<=prog)
          result(i,j)=1;
      else 
          result(i,j)=0;
      end
       
   end 
    
    
    
end









end

