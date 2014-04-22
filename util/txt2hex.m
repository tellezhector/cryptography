function bin = txt2hex(txt)
	bin = dec2hex(toascii(txt));
	bin = reshape(bin', 1, size(bin, 1)*size(bin, 2));
endfunction