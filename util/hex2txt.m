function text = hex2txt(hex)
	if(mod(size(hex, 2), 2) != 0)
		hex = ["0", hex];
	endfunction
endfunction