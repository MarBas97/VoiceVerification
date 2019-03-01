function result = mfccExtract(inputWaves)
fs=48000;
for i=1:length(inputWaves)
   
    result{i}=melcepst(inputWaves{i}, fs);    
    
end



end

