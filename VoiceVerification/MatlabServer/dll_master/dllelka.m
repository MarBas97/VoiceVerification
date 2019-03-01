% Loading the .NET assembly
lib=NET.addAssembly('F:\MATLAB\R2016a\dll_master\AesLib.dll');

%% Call of a static method
messege=uint8('ptaki lataja kluczem');
key=uint8([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32]);
iv=uint8([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]);
enc=AesLib.Crypto.EncryptBytes(messege,key,iv);
enc=uint8(enc);
dec=AesLib.Crypto.DecryptBytes(enc,key,iv);

clc;
messege=native2unicode(messege);
disp('Messege:...')
disp(messege)
disp('.......')
disp('Decrypted Messege:...')
dec=native2unicode(dec);
disp(dec)
