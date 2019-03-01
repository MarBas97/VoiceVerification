 clc
%        ________RECORDING_________



% recorder = audiorecorder(48000,16,1);
% disp('Gotowy')
% pause(1)
% disp('MÓW!')
% recordblocking(recorder,2);
% %play(recorder);
% data=getaudiodata(recorder);
% audiowrite('Nagrania_testowe3/test_5.wav',data,48000)


%% Data Input
% testing data...
directory = strcat(pwd,'\Nagrania_Seba');
seba=PrepareData(directory);

directory = strcat(pwd,'\Nagrania_Bartek');
bartek=PrepareData(directory);

directory=strcat(pwd,'\Nagrania_Mario');
mario=PrepareData(directory);

directory=strcat(pwd,'\Nagrania_Aga');
aga=PrepareData(directory);

directory=strcat(pwd,'\Nagrania_Testowe');
test=PrepareData(directory);

directory=strcat(pwd,'\Nagrania_Testowe2');
test2=PrepareData(directory);

directory=strcat(pwd,'\Nagrania_Testowe3');
test3=PrepareData(directory);



%% Feature Extraction (MFCCs)
seba_features=mfccExtract(seba);
bartek_features=mfccExtract(bartek);
mario_features=mfccExtract(mario);
aga_features=mfccExtract(aga);
test_features=mfccExtract(test);
test2_features=mfccExtract(test2);
test3_features=mfccExtract(test3); 
%% MODEL // Changing the model

%**************************************************
%**************************************************
%**************************************************

model_features=model_create(mario_features);

%**************************************************
%**************************************************
%**************************************************

%% Feature Matching (Gaussian Mixture Model)

% _______MODEL MAKING________


% options = statset('Display','final'); 
% nubmerOfComponents = 12;
% gm = fitgmdist(model_features,nubmerOfComponents,'Options',options);
% model_idx = cluster(gm,model_features);
% 
% gm=load_gm();
% prog=load_prog();

% 



%%
%**************************************************
%**************************************************
%**************************************************   
    Xa=aga_features;
    Xb=bartek_features;
    Xm=mario_features;
    Xs=seba_features;
    Xt=test_features;
    Xt2=test2_features;
    Xt3=test3_features;
%**************************************************
%**************************************************
%**************************************************


% results
[log_aga]=Clustering(Xa,gm);
[log_mario]=Clustering(Xm,gm);
[log_bartek]=Clustering(Xb,gm);
[log_seba]=Clustering(Xs,gm);
[log_test]=Clustering(Xt,gm);
[log_test2]=Clustering(Xt2,gm);
[log_test3]=Clustering(Xt3,gm);
test_result=round([log_bartek,log_seba,log_aga,log_test,log_test2,log_test3],2)/1000;

%finish
stat_and_disp(test_result,prog);


