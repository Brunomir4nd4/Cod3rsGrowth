sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/Worklist"
], function (opaTest) {
	"use strict";

	const STRING_INPUT_BLAZE = "Blaze";

	QUnit.module("Posts");

	opaTest("Should see the table with all posts", function (Given, When, Then) {
		// Arrangements
		Given.naPaginaDeListagemDosIngredientes.euInsiroBlazeNoInputNome(STRING_INPUT_BLAZE);

		// Assertions
		Then.onTheWorklistPage.theTableShouldHavePagination().
			and.theTitleShouldDisplayTheTotalAmountOfItems();
	})

	}
);