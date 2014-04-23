function bin = txt2bin(txt)
	aux = dec2bin(toascii(txt));
	bin = [];
	
	rows = size(aux,1);
	for i = 1:rows
		b = aux(i,:);
		while(mod(size(b, 2), 4)  != 0)
			b = ["0", b];
		endwhile
		bin = [bin, b];
	endfor
endfunction