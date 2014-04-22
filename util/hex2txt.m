function text = hex2txt(hex)
	if(mod(size(hex, 2), 2) != 0)
		hex = ["0", hex];
	endif
	s = size(hex, 2)/2;
	
	i = 2*(1:s)-1;
	pairs = [hex(:, i)', hex(:, i+1)'];
	text = char(hex2dec(pairs))';	
endfunction