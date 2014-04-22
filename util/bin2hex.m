function hex = bin2hex(bin)
	columns = size(bin, 2);
	if(size(bin, 1) != 1)
		error("incorrect format");
	endif
	
	while(mod(columns, 4)!= 0)
		bin = [0, bin];
		columns = size(bin, 2);
	endwhile
	
	limit = columns / 4;
	
	hex = [];
	for i = 1:limit
		index = i*4;
		c = bin(index - 3:index);
		d = bin2dec(c);
		hex = [hex, dec2hex(d)];
	endfor	
endfunction