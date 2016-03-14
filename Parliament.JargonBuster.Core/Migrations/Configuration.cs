namespace Parliament.JargonBuster.Core.Migrations
{
    using Domain;
    using Domain.Context;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Parliament.JargonBuster.Core.Domain.Context.JargonBusterDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JargonBusterDbContext context)
        {
            context.AlternateDefinitionItems.RemoveRange(context.AlternateDefinitionItems);
            context.Definitions.RemoveRange(context.Definitions);
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "A written proposal by the Government for a new law", Phrase = "white paper", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Proposal" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "A document allowing people inside and outside of Parliament to feedback on proposed laws or policies", Phrase = "green papers", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Consultation document" }, new AlternateDefinitionItem { AlternateDefinition = "feedback document" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "Around 20 senior ministers in the Government leading on policy areas such as Health, Transport or Defence", Phrase = "cabinet", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Senior Ministers" }, new AlternateDefinitionItem { AlternateDefinition = "Departmental Heads" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "An electoral system where the number of MPs elected for each party reflects the number of votes cast for each party", Phrase = "proportional representation" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "Corridors to the left and right of the chamber where MPs go to vote yes (Aye) or no (No) after a debate", Phrase = "aye and no lobbies", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Voting corridors" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "An electoral system where the candidate that received the most votes is elected in that area (used in UK General Elections)", Phrase = "first past the post" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "The senior spokespeople for the Opposition mirroring the Government's Cabinet and leading on a policy area, such as Health or Transport", Phrase = "shadow cabinet" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "An group of advisors to the monarch made up of Cabinet members past and present, the Speaker, political party leaders and others", Phrase = "privy council", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Advisors to the Monarch" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "MPs or Members of the House of Lords who are not government ministers or Opposition spokespople", Phrase = "backbenches" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "", Phrase = "orders in council" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "A rule allowing a backbench MP to speak for up to ten minutes on a proposal for a new law", Phrase = "ten minute rule bill", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Short speech" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "A rule ensuring that major Government Bills mentioned in an election manifesto can move through the Lords if the Government has no majority in the Lords", Phrase = "salisbury doctrine" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "A clause sometimes added to a proposal for a new law allowing Government to remove or amend the law in the future wihout further scrutiny ", Phrase = "henry viii clauses" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "A Member of the House of Lords who cannot pass their title to his or her children", Phrase = "life peers" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "An assistant to a minister; a volunteer role sometimes held by an MP", Phrase = "parliamentary private secretary", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Minister's assistant" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "", Phrase = "affirmative procedure" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "Leader of the Government of the day", Phrase = "prime minister", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Government leader" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "20 days allocated to the Opposition (non-government) parties to chose debate subjects", Phrase = "opposition days", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Opposition debate dayes" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "Government ministers and Opposition shadow ministers who sit on the front bench in the Chamber", Phrase = "frontbench frontbencher", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Ministers and shadow ministers" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "The 92 remaining members of the House of Lords who pass their title within their family", Phrase = "hereditary peers" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "A time when anyone can come and meet thier local MP to discuss issues, usually held once a week", Phrase = "surgeries", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "MP open meeting" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "A vote where MPs or members of the House of Lords are not put under pressure to vote a particular way by their party", Phrase = "free vote" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "", Phrase = "lords spiritual and temporal" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "A senior member of the Cabinet appointed by the Queen who heads the Ministry of Justice", Phrase = "lord chancellor" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "", Phrase = "negative procedure" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "The MPs and members of the House of Lords who are in the Government", Phrase = "minister", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Members of Government" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "", Phrase = "lord chief justice" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "Written rules for how the processes in each House are run", Phrase = "standing orders", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "House rules" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "Boxes placed on either side of the table in the Chambers where Ministers and Shadow Ministers speak", Phrase = "despatch boxes" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "A proposal for a law on taxation, public money or loans which can become law without the approval of the House of Lords", Phrase = "money bills", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "finance law proposals" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "Allows members of both Houses to be exempt from some laws, for example free speech, to ensure they can work without outside interference", Phrase = "parliamentary privilege" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "A Bill that has been agreed by both Houses of Parliament and received Royal Assent to become a law", Phrase = "acts of parliament", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "law" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "A group of Conservative MPs that meet weekly to discuss and influence Party related issues", Phrase = "1922 committee the 22" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "Ornamental clubs that must be placed in each Chamber when the members meet and pass laws ", Phrase = "mace", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Ornamental club" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "The largest political party in the House of Commons that is not in government", Phrase = "opposition the" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "A declaration of loyalty to the Monarch made by a new MP or Member of the House of Lords before taking their seat", Phrase = "oath of allegiance" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "", Phrase = "commencement order" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "When two MPs of opposing parties agree not to vote if one MP has to be absent  ", Phrase = "pairing" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "A change to a draft law or a proposed topic for debate (motion) put forward by an MP or member of the House of Lords", Phrase = "amendments" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "A Member of the House of Lords", Phrase = "peer", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Member of the House of Lords" }, new AlternateDefinitionItem { AlternateDefinition = "Lord" }, new AlternateDefinitionItem { AlternateDefinition = "Baroness" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "Members of either House who count the people that vote in the Chambers during a division ", Phrase = "tellers", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Vote counters" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "", Phrase = "presentation bills" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "A parliament made up of two seperate groups or Houses, in the UK this is the House of Commons and House of Lords", Phrase = "bi cameral system", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Two chambers" }, new AlternateDefinitionItem { AlternateDefinition = "Two House system" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "The Monarch’s agreement to make a Bill a law", Phrase = "royal assent" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "", Phrase = "programme motion" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "Members of the House of Lords that are non-party political and sit on benches crossing the chamber", Phrase = "crossbench peers", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Non-party political peers" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "Term used by MPs to interrupt a Member speaking in the House of Commons Chamber", Phrase = "give way" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "Usually made up of the party that won the most seats in the general election, the government runs the country and is led by the Prime Minister", Phrase = "government" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "The first speech made in the Chamber by a new member of the House of Commons or House of Lords", Phrase = "maiden speech", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "First speech" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "The red seat the Lord Speaker sits on in the House of Lords, made from wool from around the Commonwealth", Phrase = "woolsack" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "The Parliamentary year normally beginning in spring and running for 12 months", Phrase = "session", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Parliamentary year" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "A committee set up in the House of Commons to examine the details of a propsal for a law", Phrase = "public bill committee" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "A document explaining in plain English the purpose and effect of a Government Bill", Phrase = "explanatory notes", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Plain English notes" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "Language that breaks the rules of politeness in the House of Commons Chamber and which will be asked to be withdrawn by the Speaker", Phrase = "unparliamentary language", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Impolite language " } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "A percieved imbalance between voting rights for MPs from different nations following devolution", Phrase = "west lothian question" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "A proposal for a new law or to change an existing law", Phrase = "bills", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Proposal for law" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "A small group of senior members of the Church of England that sit in the House of Lords", Phrase = "bishops" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "The MP with the longest record of sitting continuously in the House of Commons", Phrase = "father of the house" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "Title given to most Cabinet Ministers in charge of Government Departments", Phrase = "secretary of state", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Head of Government Department" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "When the whole chamber acts in place of a committee to debate and vote on the contents of an important Bill (draft law) together", Phrase = "committee of the whole house" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "", Phrase = "delegated or secondary legislation" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "To refuse to vote for or against a proposal in the Chambers", Phrase = "abstain", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Refuse to vote" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "A document outlining the policies a Political Party stands for, shared before a General Election", Phrase = "manifesto" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "When members divide into two lobbies depending on if they are voting for or against a motion", Phrase = "divisions", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Vote" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "", Phrase = "sewel convention" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "The special right of the House of Commons to decide public taxes and public spending", Phrase = "financial privilege" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "", Phrase = "ping pong" });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "The financial assistance for Opposition parties in the House of Commons", Phrase = "short money", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Opposition funding" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "The short, half-hour debate held at the end of each day in the House of Commons", Phrase = "adjournment debates", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Final debate of the day" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "Term used to describe the other House in Parliament when in either of the Chambers", Phrase = "another place", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "The other House" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "Proposals for new laws introduced by individual MPs or members of the Lords rather than by the Government", Phrase = "private members bills", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Backbench Bills" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "An expiry date included in some laws allowing Parliament to take a second look at a law after a fixed period", Phrase = "sunset clause", Alternates = new List<AlternateDefinitionItem> { new AlternateDefinitionItem { AlternateDefinition = "Expiry date" } } });
            context.Definitions.AddOrUpdate(new DefinitionItem { Definition = "MPs or members of the House of Lords who inform and organise members from their Party in Parliament, specifically making sure members vote in line with party policy when required", Phrase = "whips" });

        }
    }
}
