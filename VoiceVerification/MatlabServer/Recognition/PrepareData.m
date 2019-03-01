function result = PrepareData(wav)
    
    b=removeSilence(wav);
    result=premfaza(b,0.95);
   
end

