context("All Compenent Test", () => {
  it("Demo", () => {
    cy.visit("http://localhost:8080/Register");
    //username
    cy.get("#rg_username").type("temir_gs");
    //password
    cy.get("#rg_password").type("12345");
    //email
    cy.get("#rg_email").type("temir.gasimov@yahoo.com");
    //Click Register Button
    cy.get("#rg_buttonRegister").click();
    //username
    cy.get("#username").type("temir_gs");
    //password
    cy.get("#password").type("12345");
    //Click Login Button
    cy.get("#login").click();
    //////////////////////////////////////////////////////
    //Name
    cy.get("#name").type("Temir");
    //Surname
    cy.get("#surname").type("Gasimov");
    //Phone Number
    cy.get("#phone").type("0515306533");
    //Brith Date
    cy.get("#brithdate").type("09.09.1999");
    //Click Add
    cy.get("#newpersonal").click();
  });
});
