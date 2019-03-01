function y = premfaza(x,wsp_prem)
%PREMFAZA Summary of this function goes here
%   Detailed explanation goes here
b=[1 ,-wsp_prem]; % do sterowania
y=conv(b,x);
y=y(1:end-1);
end

