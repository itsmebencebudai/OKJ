/// <reference types="cypress" />

function generateRandomString(length) {
  const charset = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
  let result = '';
  for (let i = 0; i < length; i++) {
    result += charset.charAt(Math.floor(Math.random() * charset.length));
  }
  return result;
}
describe('Message page testing', () => {

  const useremail = 'maci@laci.com'
  const userpassword = 'macika'


  beforeEach(() => {
    cy.visit('http://localhost:5173/')
    cy.get('input[type=email]').type(useremail)
    cy.get('input[type=password]').type(userpassword)
    cy.get('button.login-button').click()
    cy.url().should('eq', 'http://localhost:5173/chat')
  });

  it('Open message page after successfully logging in', () => {
    cy.url().should('eq', 'http://localhost:5173/chat')
  })

  it('Can send message', () => {
    const storedrandomstring = generateRandomString(10)
    cy.get('input').type(storedrandomstring);
    cy.get('.chat-input > button').click()
    cy.get(':nth-child(1) > .msg-box-right > .right-container > .message').contains(storedrandomstring)
  })

  it('User logout successfully', () => {
    cy.get('.chat-header > button').click()
    cy.url().should('eq', 'http://localhost:5173/')
  })

})