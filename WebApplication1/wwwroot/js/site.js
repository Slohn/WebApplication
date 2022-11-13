$("#providerSelect").select2({
	ajax: {
		url: "/Provider/AjaxProviders",
		dataType: "json",
		delay: 500,
		data: (params) => {
			let query = {
				search: params.term,
				/*page: params.page || 1,*/
			};

			// Query parameters will be ?search=[term]&name=Vasya%20Pupkin
			return query;
		},
		processResults: (data) => {
			let results = data.map((obj) => ({
				id: obj.id,
				text: obj.name,
			}));
			results.unshift({ id: 0, text: "без параметров" })
			return {
				results,
				//pagination: {
				//	more:
				//		data.pagesInfo.itemsCount >
				//		data.pagesInfo.itemsPerPage * data.pagesInfo.currentPage,
				//},
			};
		},
	},
	amdLanguageBase: "/lib/select2/i18n/",
	language: "ru",
	placeholder: "--",
});