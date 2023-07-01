describe('mealrecipe webpages', () => {

    it('correctly shows favourites page on first visit', () =>  {
        //Go to Favoritenpage
        cy.visit('https://localhost:7214/favoriten');
        cy.get('[data-cy=emptyFavouritesInfoBox]').should('be.visible');
        cy.get('[data-cy=mealPreviewCard]').should('not.exist');
 
    })

    it('correctly displays home and random meals', () => {
        //go to home
        cy.visit('https://localhost:7214/');
        cy.wait(500);

        //State when entering 
        cy.get('[data-cy=searchMealsSearchbar]').should('be.visible');
        cy.get('[data-cy=searchMealsButton]').should('be.visible');
        cy.get('[data-cy=mealPreviewCard]').should('not.exist');

        //click on Random meals button
        cy.wait(1000);  //give the website time to load the onclickevent
        cy.get('[data-cy=randomMealsButton]').click();

        //Meals should be visible;
        cy.get('[data-cy=listOfMealPreviews]').should('be.visible');
    })

    it('correctly displays meal detail and adds to favourites', () => {
        //Visit meal detail page
        cy.visit('https://localhost:7214/52977');
        cy.wait(500);

        //button to add to favourites is displayed
        cy.get('[data-cy=addToFavouritesButton]').should('be.visible');
        cy.get('[data-cy=addedToFavouritesInfoBox]').should('not.exist');

        //give the website time to load the onclickevent
        cy.wait(1000);
        cy.get('[data-cy=addToFavouritesButton]').click({ force: true });

        cy.wait(100);
        cy.get('[data-cy=addedToFavouritesInfoBox]').should('be.visible');

        //recipe details are displayed (button is clicked first, cause 
        //cypress scrolls to check for the following items and has problems then)
        cy.get('[data-cy=mealDetailPicture]').should('be.visible');
        cy.get('[data-cy=mealDetailIngredients]').should('be.visible');
        cy.get('[data-cy=mealDetailInstructions]').should('be.visible');
    })

    it('correctly displays favourite', () => {
        //Go to Favoritenpage
        cy.visit('https://localhost:7214/favoriten');
        cy.wait(500);

        //at least one meal should be visible
        cy.get('[data-cy=mealPreviewCard]').should('be.visible');
        cy.get('[data-cy=emptyFavouritesInfoBox]').should('not.exist');

        //Visit meal detail page again
        cy.visit('https://localhost:7214/52977');
        cy.wait(500);

        cy.get('[data-cy=addToFavouritesButton]').should('not.exist');
    })
})