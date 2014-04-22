function bin = hex2bin(hex)
	bin = [];
	for h = hex 	
		b = dec2bin(hex2dec(h));
		
		while(size(b) < 4)
			b = ["0", b];
		endwhile
		
		bin = [bin, b];
	endfor
endfunction