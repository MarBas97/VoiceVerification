function v = create_vectors(idx,nubmerOfComponents)

 v = zeros(1,nubmerOfComponents);
 
 for  i = 1:nubmerOfComponents
     numbertOfIndexes = find(idx == i);
     v(1,i) = numel(numbertOfIndexes);

end

