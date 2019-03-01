function[output] = removeSilence(input)

fs=48000;
input = input(1:end,1)/max(input(1:end,1));

% do framing
f_d = 0.025;
f_size = round(f_d * fs);
n = length(input);
n_f = floor(n/f_size);  %no. of frames
temp = 0;

for i = 1 : n_f    
   frames(i,:) = input(temp + 1 : temp + f_size);
   temp = temp + f_size;
end

% silence removal based on max amplitude
m_amp = abs(max(frames,[],2)); % find maximum of each frame
id = find(m_amp > 0.08); % finding ID of frames with max amp > 0.03
fr_ws = frames(id,:); % frames without silence

% reconstruct signal
data_r = reshape(fr_ws',1,[]);

output = data_r;
end