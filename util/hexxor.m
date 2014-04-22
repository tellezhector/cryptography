function hex = hexxor(hex1, hex2)
	bin1 = hex2bin(hex1);
	bin2 = hex2bin(hex2);
	[bin1, bin2] = even_up_with_0_to_the_right(bin1, bin2);

	binaryxor = xor((bin1 == "1")', (bin2 == "1")')';

	str = int2str(binaryxor);
	str = strrep(str, " ", "");

	hex = bin2hex(str);
endfunction