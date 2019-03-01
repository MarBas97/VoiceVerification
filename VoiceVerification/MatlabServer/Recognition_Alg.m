function THE_Decision = Recogniotion_Alg(wav_input)
fs=48000;
cd('Recognition')
wav_input=PrepareData(wav_input);
features=melcepst(wav_input,fs);
gm=load_gm();
prog=load_prog();
X=features;
[~,nlogL] = posterior(gm,X);
nlogL=round(nlogL,2)/1000;
if(nlogL<=prog)
    THE_Decision='true';
else
    THE_Decision='false';
end
cd ..\

end

