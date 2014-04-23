function key = get_key(ciptxt)
	"getting xors"
	xors = get_xors(ciptxt);
	"getting coincidencies with alphabet"
	coincidences = find_all_alphabet_coincidences(xors);
	"getting spaces"
	spaces = find_spaces_in_ciphertext(coincidences);
	"constructing key"
	key = obtain_key_from_spaces(spaces, ciptxt)
endfunction
