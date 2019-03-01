function result = distance_from_model(indexes,nubmerOfComponents)
   
   numberOfVectors = numel(indexes)
   result = zeros(numberOfVectors,1)
   v_model=create_vectors(indexes{1},nubmerOfComponents);
   
   for i = 2:numberOfVectors
       
    v1=create_vectors(indexes{i},nubmerOfComponents);
    a=sqrt(sum(abs(v_model-v1).^2));
    result(i,1) = a;
    
   end
    
end

