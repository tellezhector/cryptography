function hex = hexxor(hex1, hex2)
	bin1 = hex2bin(hex1);
	bin2 = hex2bin(hex2);
	[bin1, bin2] = pad0(bin1, bin2);

	binaryxor = xor((bin1 == "1")', (bin2 == "1")')';

	str = int2str(binaryxor);
	str = strrep(str, " ", "");

	hex = bin2hex(str);
endfunction