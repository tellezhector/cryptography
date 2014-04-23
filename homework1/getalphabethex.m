function alph = getalphabethex()
	al = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
	alph = [];
	for t=al
		alph = [alph; txt2hex(t)];
	endfor
	alph = [alph; "  "];
endfunction
