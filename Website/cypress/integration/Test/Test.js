/// <reference types="cypress" />
///https://on.cypress.io/introduction-to-cypress

describe('Final Year Project', () => {
    beforeEach(() => {
        cy.visit('http://bf118.webhosting.canterbury.ac.uk/')
    })

    it('can see four encounter Buttons', () => {

        cy.get('button').contains('Encounter1')
        cy.get('button').contains('Encounter2')
        cy.get('button').contains('Encounter3')
        cy.get('button').contains('Encounter4')
    })

    it('Clicks encounter 1 and 4 buttons', () => {
        cy.get('button').contains('Encounter1').click()
        cy.get('button').contains('Encounter4').click()
    })
    it('Create signup updates sheet', () => {

       cy.get('button').contains('Create Signup').click()

    
    })
    it('Open Discord invite', () => {
        cy.get('[alt="Discord"]').invoke('removeAttr', 'target').click()
    })
    it('Add username to role sign up', () => {
        cy.get('input[name=username]').type('testuser')
        cy.get('button').contains('Click here to sign up').click()
        cy.get('input[name=baseTank]').should('have.value', 'testuser')
    })
    it('Check role information', () => {
        cy.get('[alt=baseTank]').invoke('removeAttr', 'target').click()
        cy.get('p').contains('I am the base')
    })
    it('Can close modal', () => {
        cy.get('[alt=baseTank]').invoke('removeAttr', 'target').click()
        cy.get('[class="popup__close"]').contains('Press here to Close').click()
    })
    it('Can count number of roles assigned', () => {
        cy.get('input[name=username]').type('testuser')
        cy.get('button').contains('Click here to sign up').click()
        cy.get('p').should('have.value', '')
    })
})
