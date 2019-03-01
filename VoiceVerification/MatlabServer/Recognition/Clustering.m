function [NLOG] = Clustering(X,gm)

for i=1:length(X)    
    

[P,nlogL] = posterior(gm,X{i});
NLOG(i,1)=nlogL;


end

end

