function bin = txt2bin(txt)
	bin = dec2bin(toascii(txt));
	bin = reshape(bin, 1, size(bin, 1)*size(bin, 2));
endfunction