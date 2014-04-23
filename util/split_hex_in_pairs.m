function pairs = split_hex_in_pairs(hex)
	if(mod(size(hex, 2), 2) != 0)
		hex = ["0", hex];
	endif
	
	pairs = reshape(hex, 2, [])';
endfunction