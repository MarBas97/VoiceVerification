while(1)
clear all

t= tcpip('localhost',5000,'NetworkRole','server');
set(t,'InputBufferSize',400000);

fopen(t);
while(t.BytesAvailable > 0) 
 
  disp('Connection succeed.');
  rawData = fread(t,t.BytesAvailable,'uint8'); 

end




%%
data = uint8(rawData);
dir = strcat(pwd,'\dll_master\AesLib.dll');
lib=NET.addAssembly(dir);

key=uint8([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32]);
iv=uint8([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]);

dec=AesLib.Crypto.DecryptBytes(data,key,iv);
dec=native2unicode(dec);
dec = unicode2native(dec);
%%
wav = double(typecast(uint8(dec(:)),'int16'));
wav = wav ./ 3.2768e+04; 

decision=Recognition_Alg(wav);

fwrite(t,decision,'uint8');
fclose(t);
end



